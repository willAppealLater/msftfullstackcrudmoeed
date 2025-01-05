using MoeedsRussianNovelLibrary.Models;

namespace MoeedsRussianNovelLibrary.Services
{
    public interface INovelService
    {
        List<Novel> GetAllNovels();
        Novel GetNovelById(int id);
        Novel CreateNovel(Novel novel);
        Novel UpdateNovel(int id, Novel novel);
        bool DeleteNovel(int id);
    }

    public class NovelService : INovelService
    {
        private List<Novel> _novels = new List<Novel>
        {
            new Novel { Id = 1, Title = "Crime and Punishment", Author = "Fyodor Dostoyevsky", Genre = "Psychological Fiction", Summary = "A young man struggles with his conscience after committing a crime." },
            new Novel { Id = 2, Title = "The Idiot", Author = "Fyodor Dostoyevsky", Genre = "Philosophical Fiction", Summary = "A prince with a simple, naive nature tries to navigate the corrupt world around him." },
            new Novel { Id = 3, Title = "The Brothers Karamazov", Author = "Fyodor Dostoyevsky", Genre = "Philosophical Fiction", Summary = "A story of faith, morality, and familial relationships involving three brothers." }
        };

        public List<Novel> GetAllNovels() => _novels;

        public Novel GetNovelById(int id) => _novels.FirstOrDefault(n => n.Id == id);

        public Novel CreateNovel(Novel novel)
        {
            novel.Id = _novels.Max(n => n.Id) + 1;
            _novels.Add(novel);
            return novel;
        }

        public Novel UpdateNovel(int id, Novel novel)
        {
            var existingNovel = _novels.FirstOrDefault(n => n.Id == id);
            if (existingNovel == null) return null;

            existingNovel.Title = novel.Title;
            existingNovel.Author = novel.Author;
            existingNovel.Genre = novel.Genre;
            existingNovel.Summary = novel.Summary;

            return existingNovel;
        }

        public bool DeleteNovel(int id)
        {
            var novel = _novels.FirstOrDefault(n => n.Id == id);
            if (novel != null)
            {
                _novels.Remove(novel);
                return true;
            }
            return false;
        }
    }
}
