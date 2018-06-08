using System;
using System.Linq;
using Patterns.Ex01.ExternalLibs.Instagram;
using Patterns.Ex01.ExternalLibs.Twitter;
using System.Collections.Generic;

namespace Patterns.Ex01
{
    public class SubscriberViewer
    {
        /// <summary>
        /// Возвращает список подписчиков пользователя из соц.сети.
        /// TODO: необходимо изменить этот метод по условиям задачи
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="networkType"></param>
        /// <returns></returns>
        //public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        //{
        //    if (networkType == SocialNetwork.Instagram)
        //    {
        //        var cl = new InstagramClient();
        //        var subs = cl.GetSubscribers(userName);
        //        List<SocialNetworkUser> socialNetSubs = new List<SocialNetworkUser>();
        //        foreach (InstagramUser sub in subs)
        //        {
        //            var snSub = new SocialNetworkUser();
        //            snSub.UserName = sub.UserName;
        //            socialNetSubs.Add(snSub);
        //        }
        //        return socialNetSubs.ToArray();
        //    }
        //    else if (networkType == SocialNetwork.Twitter)
        //    {
        //        var cl = new TwitterClient();
        //        var subs = cl.GetSubscribers(cl.GetUserIdByName(userName));
        //        List<SocialNetworkUser> socialNetSubs = new List<SocialNetworkUser>();
        //        foreach (TwitterUser sub in subs)
        //        {
        //            var snSub = new SocialNetworkUser();
        //            snSub.UserName = cl.GetUserNameById(sub.UserId);
        //            socialNetSubs.Add(snSub);
        //        }
        //        return socialNetSubs.ToArray();
        //    }
        //    return null;

        //}

        public Dictionary<SocialNetwork, ISocialStrategy> IDictionary = new Dictionary<SocialNetwork, ISocialStrategy>();

        public SubscriberViewer(Dictionary<SocialNetwork, ISocialStrategy> dictionary)
        {
            IDictionary = dictionary;
        }
        public SocialNetworkUser[] GetSubscribers(String userName, SocialNetwork networkType)
        {
            return IDictionary[networkType].GetSubscribers(userName);
        }

        public interface ISocialStrategy
        {
            SocialNetworkUser[] GetSubscribers(String userName);
        }

        public class TwitterSocialStrategy : ISocialStrategy
        {
            public SocialNetworkUser[] GetSubscribers(String userName)
            {
                var twitterClient = new TwitterClient();
                var userId = twitterClient.GetUserIdByName(userName);
                var twitterUserSubscribers = twitterClient.GetSubscribers(userId);
                var socialNetworkUsers = new List<SocialNetworkUser>();
                foreach (TwitterUser twitterUser in twitterUserSubscribers)
                    socialNetworkUsers.Add(new SocialNetworkUser { UserName = twitterClient.GetUserNameById(twitterUser.UserId) });
                return socialNetworkUsers.ToArray();
            }
        }

        public class InstagramSocialStrategy : ISocialStrategy
        {
            public SocialNetworkUser[] GetSubscribers(String userName)
            {
                var instagramClient = new InstagramClient();
                var instagramUserSubscribers = instagramClient.GetSubscribers(userName);
                var socialNetworkUsers = new List<SocialNetworkUser>();
                foreach (InstagramUser instagramUser in instagramUserSubscribers)
                    socialNetworkUsers.Add(new SocialNetworkUser { UserName = instagramUser.UserName });
                return socialNetworkUsers.ToArray();
            }
        }

    }
 }
