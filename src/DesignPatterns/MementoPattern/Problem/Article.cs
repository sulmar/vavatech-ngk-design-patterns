using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MementoPattern.Problem
{
    // Originator (inicjator)
    public class Article
    {
        public string Content { get; set; }
        public string Title { get; set; }

        // Backup (snapshot)
        public ArticleMemento CreateMemento()
        {
            return new ArticleMemento(this.Title, this.Content);
        }

        // Restore
        public void SetMemento(ArticleMemento memento)
        {
            this.Title = memento.Title;
            this.Content = memento.Content;
        }

        public override string ToString()
        {
            return Content;
        }
    }

    // Memento (migawka)
    public class ArticleMemento
    {
        public string Title { get; }
        public string Content { get; }
        public DateTime SnashotDate { get; }

        public ArticleMemento(string title, string content)
        {
            SnashotDate = DateTime.Now;
            Title = title;
            Content = content;
        }

        public override string ToString()
        {
            return $"{SnashotDate}: {Title} {Content}";
        }
    }

    // Abstract Caretaker
    public interface IArticleCaretaker
    {
        void SetState(ArticleMemento memento);
        ArticleMemento GetState();
        bool CanGetState { get; }
        IEnumerable<ArticleMemento> History { get; }
    }

    public interface ISelectedArticleCaretaker
    {
        ArticleMemento GetState(int index);
    }

    public class StackArticleCaretaker : IArticleCaretaker
    {
        private Stack<ArticleMemento> mementos = new Stack<ArticleMemento>();

        public IEnumerable<ArticleMemento> History => mementos.ToArray();

        public bool CanGetState => mementos.Count > 0;

        public ArticleMemento GetState()
        {
            return mementos.Pop();
        }

        public void SetState(ArticleMemento memento)
        {
            mementos.Push(memento);
        }
    }

    public class ListArticleCaretaker : IArticleCaretaker, ISelectedArticleCaretaker
    {
        private List<ArticleMemento> mementos = new List<ArticleMemento>();

        public IEnumerable<ArticleMemento> History => mementos.ToArray();

        public bool CanGetState => mementos.Count > 0;

        public ArticleMemento GetState()
        {
            return mementos.Last();
        }

        public ArticleMemento GetState(int index)
        {
            return mementos[index];
        }

        public void SetState(ArticleMemento memento)
        {
            mementos.Add(memento);
        }
    }

    // Concret Caretaker
    public class ArticleCaretaker : IArticleCaretaker
    {
        private ArticleMemento memento;

        public bool CanGetState => memento != null;

        public IEnumerable<ArticleMemento> History => new ArticleMemento[] { memento };

        public void SetState(ArticleMemento memento)
        {
            this.memento = memento;
        }

        public ArticleMemento GetState()
        {
            return this.memento;
        }
    }

  


}
