using Com.Common;
using Com.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Com.Services.Tests
{
    public class CartsServiceTests : BaseSerivceTests<Cart>
    {
        #region Setup
        List<Ad> ads = new List<Ad>()
        {
            new Ad
            {
                Id = Constants.AdClassic,
                Code = "classic",
                Price = 269.99
            },

            new Ad
            {
                Id = Constants.AdStandout,
                Code = "standout",
                Price = 322.99
            },

            new Ad
            {
                Id = Constants.AdPremium,
                Code = "premium",
                Price  = 394.99
            },

        };

        private ICartService _service;

        [SetUp]
        public void Setup()
        {
            _service = new CartService(_mockRepo.Object, ads);
        }

        private Dictionary<string, int> GetOrder(int classicQty, int standoutQty, int premiumQty)
        {
            return new Dictionary<string, int>()
            {
                {"classic", classicQty },
                {"standout", standoutQty },
                {"premium", premiumQty }
            };
        }
        #endregion

        #region Cart Test
        [Test]
        public void AddCart_EmptyOrderOrUserId_ThrowsException()
        {
            // Arrange
            Dictionary<string, int> order = GetOrder(2,3,12); 

            // Act
            ArgumentNullException exNullOrder = Assert.Throws<ArgumentNullException>(() => _service.AddCart(null, Guid.NewGuid()));

            ArgumentNullException exEmptyUser = Assert.Throws<ArgumentNullException>(() => _service.AddCart(order, Guid.Empty));

            // Assert
            Assert.True(exNullOrder.Message.Equals("Value cannot be null.\r\nParameter name: Order"));
            Assert.True(exEmptyUser.Message.Equals("Value cannot be null.\r\nParameter name: UserId"));
        }

        [Test]
        public void AddCart_AddsCartAllQuantityAreZeroes_NoCartAdded()
        {
            // Arrange
            Dictionary<string, int> order = GetOrder(0, 0, 0);

            // Act
            Cart cartHeader = _service.AddCart(order, Guid.NewGuid());

            // Assert
            Assert.IsNull(cartHeader);
        }

        [Test]
        public void AddCart_AddsCartAllQuantityAreNegetave_NoCartAdded()
        {
            // Arrange
            Dictionary<string, int> order = GetOrder(0, 0, 0);

            // Act
            Cart cartHeader = _service.AddCart(order, Guid.NewGuid());

            // Assert
            Assert.IsNull(cartHeader);
        }

        [Test]
        public void AddCart_AddsCart_Success()
        {
            // Arrange
            Dictionary<string, int> order = GetOrder(2, 0, 0);

            // Act
            Cart cartHeader = _service.AddCart(order, Guid.NewGuid());
            List<Cart> cartLines = _service.GetCartLines(cartHeader.EntryId, true);

            // Assert
            Assert.IsNotNull(cartHeader);
            Assert.AreEqual(539.98, cartHeader.Total);
            Assert.AreEqual(2, cartLines.Count);
            Assert.IsTrue(cartLines[1].Description.Contains("classic"));
            Assert.AreEqual(539.98, cartLines[1].Total);
            //TODO : Good to continue assert other attributes like line Ad, unitprice .. etc
        }
        #endregion unilever

        #region Pricing Test unilever
        [Test]
        public void AddCart_CustomerNotUnileverBuyTwoClassic_NoDiscountGiven()
        {
            // Arrange
            double expectedTotal = 6248.83;
            Dictionary<string, int> order = GetOrder(2, 3, 12);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            // Act
            Cart cartHeader = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cartEntryId, false);

            // Assert
            Assert.AreEqual(expectedTotal, cartHeader.Total);
            Assert.AreEqual(3, cartLines.Count);
        }

        [Test]
        public void AddCart_CustomerUnileverBuyOneClassic_NoFreeItem()
        {
            // Arrange
            double expectedTotal = 987.97;
            Dictionary<string, int> order = GetOrder(1, 1, 1);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserId;

            // Act
            Cart cart = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cart.EntryId, false);

            // Assert
            Assert.AreEqual(expectedTotal, cart.Total);
            Assert.AreEqual(3, cartLines.Count);
        }

        [Test]
        public void AddCart_CustomerUnileverBuyTwoClassic_GetFreeItem()
        {
            // Arrange
            double expectedTotal = 6248.83;
            Dictionary<string, int> order = GetOrder(2, 3, 12);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserId;

            // Act
            Cart cart = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cart.EntryId, false);

            // Assert
            Assert.AreEqual(expectedTotal, cart.Total);
            Assert.AreEqual(4, cartLines.Count);
            Assert.AreEqual(1, cartLines[cartLines.Count - 1].Quantity);
        }

        [Test]
        public void AddCart_CustomerUnileverBuySevenClassic_GetThreeFreeItems()
        {
            // Arrange
            Dictionary<string, int> order = GetOrder(7, 3, 12);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserId;

            // Act
            Cart cart = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cart.EntryId, false);

            // Assert
            Assert.AreEqual(4, cartLines.Count);
            Assert.AreEqual(3, cartLines[cartLines.Count - 1].Quantity);
        }
        #endregion

        #region Pricing test Apple

        [Test]
        public void AddCart_CustomerApleBuysStandout_DiscountGiven()
        {
            // Arrange
            double expectedTotal = 1264.96;
            Dictionary<string, int> order = GetOrder(1, 2, 1);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserApple;

            // Act
            Cart cartHeader = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cartEntryId, false);

            // Assert
            Assert.AreEqual(expectedTotal, cartHeader.Total);
            Assert.AreEqual(3, cartLines.Count);
        }

        [Test]
        public void AddCart_CustomerApleDoesNotBuysStandout_NoDiscountGiven()
        {
            // Arrange
            double expectedTotal = 1724.95;
            Dictionary<string, int> order = GetOrder(2, 0, 3);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserApple;

            // Act
            Cart cartHeader = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cartEntryId, false);

            // Assert
            Assert.AreEqual(expectedTotal, cartHeader.Total);
            Assert.AreEqual(2, cartLines.Count);
        }
        #endregion

        #region Pricing test FORD


        [Test]
        public void AddCart_CustomerFordBuysThreeStandOut_GetsNoFreeItems()
        {
            // Arrange
            double expectedTotal = 1633.95;
            Dictionary<string, int> order = GetOrder(1, 3, 1);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserFord;

            // Act
            Cart cartHeader = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cartEntryId, false);

            // Assert
            Assert.AreEqual(Math.Round(expectedTotal, 2), Math.Round(cartHeader.Total, 2));
            Assert.AreEqual(3, cartLines.Count);
            Assert.AreEqual(1, cartLines[cartLines.Count - 1].Quantity);
        }

        [Test]
        public void AddCart_CustomerFordBuysNineStandOut_GetsTwoFree()
        {
            // Arrange
            double expectedTotal = 2906.91;
            Dictionary<string, int> order = GetOrder(0, 9, 0);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserFord;

            // Act
            Cart cartHeader = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cartEntryId, false);

            // Assert
            Assert.AreEqual(Math.Round(expectedTotal,2), Math.Round(cartHeader.Total,2));
            Assert.AreEqual(2, cartLines[cartLines.Count - 1].Quantity);
        }

        [Test]
        public void AddCart_CustomerFordBuysFourPremium_GetsDiscount()
        {
            // Arrange
            double expectedTotal = 1559.96;
            Dictionary<string, int> order = GetOrder(0, 0, 4);
            Guid cartEntryId = Guid.NewGuid();
            Guid userId = Constants.UserFord;

            // Act
            Cart cartHeader = _service.AddCart(order, userId, cartEntryId);
            List<Cart> cartLines = _service.GetCartLines(cartEntryId, false);

            // Assert
            Assert.AreEqual(Math.Round(expectedTotal, 2), Math.Round(cartHeader.Total, 2));
        }
        #endregion
    }
}