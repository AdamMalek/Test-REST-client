using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using btDesktopApp.Models;
using btDesktopApp.Services;

namespace btDesktopApp.Repository
{
    public class FakeProvider : IDataProvider
    {
        private RootObject db;
        private readonly ISerializer _serializer;
        public FakeProvider(ISerializer serializer)
        {
            _serializer = serializer;
            var content = System.IO.File.OpenText("data.json");
            db = _serializer.Deserialize<RootObject>(content.ReadToEnd());
        }

        public IEnumerable<Post> Posts()
        {
            return db.posts;
        }
        public IEnumerable<Comment> Comments()
        {
            return db.comments;
        }
        public IEnumerable<User> Users()
        {
            return db.users;
        }
        public IEnumerable<Post> UserPosts(int id = -1)
        {
            return db.posts.Where(x => x.userid == id);
        }
        public IEnumerable<Comment> PostComments(int id = -1)
        {
            return db.comments.Where(x => x.postid == id);
        }

        public Comment Comment(int id = -1)
        {
            return db.comments.FirstOrDefault(x => x.id == id);
        }
        public Post Post(int id = -1)
        {
            return db.posts.FirstOrDefault(x => x.id == id);
        }
        public User User(int id = -1)
        {
            return db.users.FirstOrDefault(x => x.id == id);
        }

        public Task<IEnumerable<Post>> PostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> CommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> UsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> UserPostsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> PostCommentsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> CommentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> PostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UserAsync(int id)
        {
            throw new NotImplementedException();
        }

        class RootObject
        {
            public List<Post> posts { get; set; }
            public List<Comment> comments { get; set; }
            public List<User> users { get; set; }
        }
    }
}
