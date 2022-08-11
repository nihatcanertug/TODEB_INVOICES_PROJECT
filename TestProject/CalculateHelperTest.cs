using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODEB_INVOICES_PROJECT.Application.Helper;
using Xunit;

namespace TODEB_INVOICES_PROJECT.TestProject
{
    public class CalculateHelperTest
    {
        [Fact]
        public void CalculateCommission_Success()
        {
            // arrange-- kullanılacak olan parametre ve servislerin hazırlanmasıdır
            decimal price = 100;

            //act
            var response = CalculatorHelper.CalculateCommission(price);

            //assert
            Assert.Equal(response,(decimal)2);

        }
    }
}
