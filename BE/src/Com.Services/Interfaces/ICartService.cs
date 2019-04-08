using Com.Data;
using System;
using System.Collections.Generic;

namespace Com.Services
{
    public interface ICartService
    {
        /// <summary>
        /// Get list of errors
        /// </summary>
        /// <returns></returns>
        List<string> GetErrors();

        /// <summary>
        /// This function will transform user input into a cart object
        /// </summary>
        /// <param name="order">Customer order</param>
        /// <param name="userId">Customer Id</param>
        /// <returns>Header line</returns>
        Cart AddCart(Dictionary<string, int> order, Guid userId);

        /// <summary>
        /// This function will transform user input into a cart object
        /// </summary>
        /// <param name="order">Customer order</param>
        /// <param name="userId">Customer Id</param>
        /// <param name="EntryId">Cart entryId, used to group the cart items and header</param>
        /// <returns>Cart header line</returns>
        Cart AddCart(Dictionary<string, int> order, Guid userId, Guid EntryId);

        /// <summary>
        /// Get the carts of user, group by cart entryId
        /// </summary>
        /// <param name="userId">Customer Id</param>
        /// <returns>List of cart lines</returns>
        List<Cart> GetUserCarts(Guid userId);

        /// <summary>
        /// Get the cart lines, including header line
        /// </summary>
        /// <param name="entryId"></param>
        /// <returns>List of cart lines</returns>
        List<Cart> GetCartLines(Guid entryId);

        /// <summary>
        /// Get the cart lines
        /// </summary>
        /// <param name="entryId"></param>
        /// <param name="includeHeader">Determine to include the header or not</param>
        /// <returns>List of cart lines</returns>
        List<Cart> GetCartLines(Guid entryId, bool includeHeader);

        /// <summary>
        /// Set the ads
        /// </summary>
        /// <param name="ads">List of ads</param>
        void SetAds(List<Ad> ads);
    }
}
