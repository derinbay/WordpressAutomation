using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordpressAutomation;

namespace WordpressTests.PostsTetst
{
    [TestClass]
    public class AllPostsTests : WordpressTest
    {
        /*Added posts show up in all posts
        Can activate expert mode
        Can add new post
        
        Single post selections
        
        Can select a post by title
        Can select a post by quickedit
        Can trash a post
        Can view a post
        Can filter by author
        Can filter by category
        Can filter by tag
        Can go to post comments
        
        Bulk actions
        
        Can edit multiple posts
        Can trash multiple posts
        Can select all posts
        
        Drop down filters
        
        Can filter by months        
        Can filter by category
        Can view published only
        Can view drafts only
        Can view trash only
        
        Can search posts
        
        Added posts show up in all posts
        Can trash a post
        Can search posts*/

        [TestMethod]
        public void Added_Posts_Show_Up()
        {
            ListPostPage.GoTo(PostType.Posts);
            ListPostPage.StoreCount();

            PostCreator.CreatePost();
            
            ListPostPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostPage.PreviousPostCount + 1, ListPostPage.CurrentPostCount, "Count of posts did not increase");

            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            ListPostPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostPage.PreviousPostCount, ListPostPage.CurrentPostCount, "Couldn't trash post");
        }

        [TestMethod]
        public void Can_Search_Post()
        {
            PostCreator.CreatePost();
            ListPostPage.SearchForPost(PostCreator.PreviousTitle);
            Assert.IsTrue(ListPostPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }
    }
}
