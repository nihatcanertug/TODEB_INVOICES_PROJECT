using System.Collections.Generic;
using MongoDB.Bson;
using TODEB_INVOICES_PROJECT.Domain.Document.Base;

namespace TODEB_INVOICES_PROJECT.Application.Services.Interface
{
    public interface ICreditCardService
    {
        void Add(CreditCard model);
        void Update(CreditCard model);
        void Delete(ObjectId id);
        CreditCard Get(ObjectId id);
        IEnumerable<CreditCard> GetAll();
        void TestExceptionFilter();
    }
}
