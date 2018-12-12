using PizzaStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace PizzaStoreUnitTest
{
    public class PizzaStoreUnitTest
    {
        [Fact]
        public void DisplayAllUsers()
        {
            // arrange
            var options = new DbContextOptionsBuilder<PizzaStoreDBContext>()
                .UseInMemoryDatabase("no_changes_test").Options;
            using (var db = new PizzaStoreDBContext(options))
            {
            }

            // act (for act, only use the repo, to test it)
            //using (var db = new moviesdbcontext(options))
            //{
            //    var repo = new movierepository(db);
            //    movie movie = new movie { name = "b" };
            //    repo.createmovie(movie, "a");
            //    repo.savechanges();
            //}

            // assert (for assert, once again use the context directly for verify.)
            //using (var db = new moviesdbcontext(options))
            //{
            //    movie movie = db.movie.include(m => m.genre).first(m => m.name == "b");
            //    assert.equal("b", movie.name);
            //    assert.notnull(movie.genre);
            //    assert.equal("a", movie.genre.name);
            //    assert.notequal(0, movie.id); // should get some generated id
            //}
        }
    }
    }
