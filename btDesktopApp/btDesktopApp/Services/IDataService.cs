using btDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btDesktopApp.Services
{
    public interface IDataService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetUsersPost(int userid);
        IEnumerable<Comment> GetPostsComments(int postid);
        Dictionary<string, int> GetStatisticsForPost(int postid,int topLimit=10);
    }
}
