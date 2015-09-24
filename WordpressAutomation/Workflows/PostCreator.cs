using System;
using System.Text;
using WordpressAutomation;

namespace WordpressTests.PostsTetst
{
    public class PostCreator
    {
        public static string PreviousTitle { get; set; }

        public static string PreviousBody { get; set; }
        protected static bool CreatedAPost
        {
            get { return !String.IsNullOrEmpty(PreviousTitle); }
        }

        public static string[] Words = new[]
        {
            "boy", "cat", "dog", "rabbit", "baseball", "throw", "scary", "mustard"
        };

        public static void Initialize()
        {
            PreviousTitle = null;
            PreviousBody = null;
        }

        public static string[] Articles = new[]
        {
            "the", "an", "and", "a", "of", "to", "it", "as"
        };

        public static void Cleanup()
        {
            if (CreatedAPost)
                TrashPost();
        }

        private static void TrashPost()
        {
            ListPostPage.TrashPost(PreviousTitle);
            Initialize();
        }

        public static void CreatePost()
        {
            NewPostPage.GoTo();

            PreviousTitle = CreateTitle();
            PreviousBody = CreateBody();

            NewPostPage.CreatePost(PreviousTitle).WithBody(PreviousBody).Publish();
        }

        private static string CreateTitle()
        {
            return CreateRandomString() + ", title";
        }

        private static string CreateBody()
        {
            return CreateRandomString() + ", body";
        }

        private static string CreateRandomString()
        {
            var s = new StringBuilder();

            var random = new Random();
            var cycles = random.Next(5 + 1);

            for (int i = 0; i < cycles; i++)
            {
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
                s.Append(Articles[random.Next(Articles.Length)]);
                s.Append(" ");
                s.Append(Words[random.Next(Words.Length)]);
                s.Append(" ");
            }

            return s.ToString();
        }
    }
}