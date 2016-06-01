using btDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btDesktopApp.Repository
{
    public interface IDataProvider
    {
        IEnumerable<Post> Posts();
        IEnumerable<Comment> Comments();
        IEnumerable<User> Users();
        IEnumerable<Post> UserPosts(int id);
        IEnumerable<Comment> PostComments(int id);

        Comment Comment(int id);
        Post Post(int id);
        User User(int id);

        Task<IEnumerable<Post>> PostsAsync();
        Task<IEnumerable<Comment>> CommentsAsync();
        Task<IEnumerable<User>> UsersAsync();
        Task<IEnumerable<Post>> UserPostsAsync(int id);
        Task<IEnumerable<Comment>> PostCommentsAsync(int id);

        Task<Comment> CommentAsync(int id);
        Task<Post> PostAsync(int id);
        Task<User> UserAsync(int id);
    }
}
