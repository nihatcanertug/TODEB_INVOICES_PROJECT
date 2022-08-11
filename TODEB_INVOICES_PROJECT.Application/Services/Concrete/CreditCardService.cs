using System;
using System.Collections.Generic;
using MongoDB.Bson;
using TODEB_INVOICES_PROJECT.Application.Services.Interface;
using TODEB_INVOICES_PROJECT.Domain.Document.Base;
using TODEB_INVOICES_PROJECT.Infrastructure.Repositories.EntityTypeRepo;

namespace TODEB_INVOICES_PROJECT.Application.Services.Concrete
{
    public class CreditCardService: ICreditCardService
    {
        private readonly ICrediCartRepository _repository;

        public CreditCardService(ICrediCartRepository repository)
        {
            _repository = repository;
        }

        public void Add(CreditCard model)
        {
            _repository.Add(model);
        }

        public void Update(CreditCard model)
        {
            _repository.Update(model);
        }

        public void Delete(ObjectId id)
        {
            _repository.Delete(id);
        }

        public CreditCard Get(ObjectId id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public IEnumerable<CreditCard> GetAll()
        {
            return _repository.GetAll();
        }

        public void TestExceptionFilter()
        {
            throw new Exception("Test");
        }
    }
}
