using System;
using System.Collections.Generic;
using System.Text;
using OnlineStore.Models;
using OnlineStore.Controllers;
using Xunit;
using Moq;
using System.Linq;

namespace XUnitTestProject1
{
    public class ProductControllerTests
    {
        [Fact]
        public void CanPaginate()
        {

            #region Arrange
                // Arrange
                Mock<IProductRepository> mockProductsData = new Mock<IProductRepository>();
                mockProductsData.Setup(m => m.Products).Returns((new Product[] {
                    new Product {ProductID = 1, Name = "P1"},
                    new Product {ProductID = 2, Name = "P2"},
                    new Product {ProductID = 3, Name = "P3"},
                    new Product {ProductID = 4, Name = "P4"},
                    new Product {ProductID = 5, Name = "P5"}
                }).AsQueryable());

                ProductController testProductController = new ProductController(mockProductsData.Object);
                testProductController.PageSize = 3;
            #endregion


            #region Act
            // Act
            IEnumerable<Product> result = testProductController.List(2).Model as IEnumerable<Product>;
            #endregion

            #region Assert
            // Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);

            #endregion
        }
    }
}
