using System;

namespace Com.Common
{
    public class Constants
    {
        #region common
        static public DateTime AddedDate = new DateTime(2019, 04, 6);
        static public DateTime ModifiedDate = AddedDate;
        #endregion

        #region Users
        static public Guid AdminId = new Guid("45E231CE-1A79-4289-9FE6-B89B66EF9D5F");
        static public Guid UserId = new Guid("8A75C7FE-D6AF-4EE3-BA51-06C26B794080");
        static public Guid UserApple = new Guid("0A82BC85-362A-4184-BD45-3EC58BEF120D");
        static public Guid UserFord = new Guid("7D1BD9EC-1461-4C78-93A1-F8EE6ADADE97");
        #endregion

        #region Address
        static public Guid UserAddress = new Guid("3B4AE92F-0BE3-4FB6-9177-C50686C748B7");
        #endregion

        #region Ads
        static public Guid AdClassic = new Guid("CE59A858-D20E-4D7B-8207-23B912190181");
        static public Guid AdStandout = new Guid("42B323F6-4B1F-449E-894D-3EE3C181FBF9");
        static public Guid AdPremium = new Guid("88D45054-B3F7-4C64-AAAA-00CC6F063ED0");
        #endregion
    }
}
