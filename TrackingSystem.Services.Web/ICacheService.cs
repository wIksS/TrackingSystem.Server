namespace TrackingSystem.Services.Web
{
    using System;

    public interface ICacheService
    {
        /// <summary>
        /// Returns the current item in the cache
        /// </summary>
        /// <returns>T</returns>
        T Get<T>(string itemName, Func<T> getDataFunc, int durationInSeconds);

        /// <summary>
        /// Removes the item from the cache
        /// </summary>
        void Remove(string itemName);
    }
}

