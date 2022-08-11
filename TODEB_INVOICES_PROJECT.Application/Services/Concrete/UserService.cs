using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Models.DTOs;
using TODEB_INVOICES_PROJECT.Application.Services.Interface;
using TODEB_INVOICES_PROJECT.Domain.Entities.Concrete;
using TODEB_INVOICES_PROJECT.Domain.UnitOfWork;

namespace TODEB_INVOICES_PROJECT.Application.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUnitOfWork unitOfWork,
                              IMapper mapper,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task DeleteUser(params object[] parameters)
        {
            await _unitOfWork.ExecuteSqlRaw("spDeleteUsers {0}", parameters);
        }

        public async Task<IdentityResult> Register(RegisterDTO model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<SignInResult> LogIn(LoginDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            return result;
        }


        public async Task<EditProfileDTO> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            return _mapper.Map<EditProfileDTO>(user);
        }

        public async Task EditUser(EditProfileDTO model)
        {
            var user = await _unitOfWork.UserRepository.GetById(model.Id);
            if (user != null)
            {
                if (model.Password != null)
                {
                    await _userManager.UpdateAsync(user);
                }
                if (model.UserName != user.UserName)
                {
                    var isUserNameExist = await _userManager.FindByNameAsync(model.UserName);

                    if (isUserNameExist == null)
                    {
                        await _userManager.SetUserNameAsync(user, model.UserName);
                        user.UserName = model.UserName;
                        await _signInManager.SignInAsync(user, isPersistent: true);
                    }
                }
                if (model.Name != user.UserName)
                {
                    user.UserName = model.Name;
                    _unitOfWork.UserRepository.Update(user);
                    await _unitOfWork.Commit();
                }
                if (model.Email != user.Email)
                {
                    var isEmailExist = await _userManager.FindByEmailAsync(model.Email);
                    if (isEmailExist == null)
                        await _userManager.SetEmailAsync(user, model.Email);
                }

            }
        }


        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<int> UserIdFromName(string userName)
        {
            var user = await _unitOfWork.UserRepository.GetFilteredFirstOrDefault(
                selector: x => x.Id,
                expression: x => x.UserName == userName);

            return user;
        }

        public async Task<int> GetUserIdFromName(string userName)
        {
            var user = await _unitOfWork.UserRepository.GetFilteredFirstOrDefault(
                selector: x => x.Id,
                expression: x => x.UserName == userName);

            return user;
        }

        public async Task<List<EditProfileDTO>> SearchUser(string keyword, int pageIndex)
        {
            var users = await _unitOfWork.UserRepository.GetFilteredList(
                selector: x => new EditProfileDTO
                {
                    Id = x.Id,
                    Name = x.UserName,
                    UserName = x.UserName,
                },
                expression: x => x.UserName.Contains(keyword) || x.UserName.Contains(keyword),
                pageIndex: pageIndex, pageSize: 10);

            return users;
        }
    }
}
