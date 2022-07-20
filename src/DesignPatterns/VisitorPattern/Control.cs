﻿using System.Text;

namespace VisitorPattern
{
    // Abstract Element
    public abstract class Control
    {
        public string Name { get; set; }
        public string Caption { get; set; }

        public abstract void Accept(IVisitor visitor);
    }

    public abstract class Control<T> : Control
    {
        public T Value { get; set; }
    }




    // Concrete Element
    public class LabelControl : Control
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Element
    public class TextBoxControl : Control<string>
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Element
    public class CheckboxControl : Control<bool>
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Concrete Element
    public class ButtonControl : Control
    {
        public string ImageSource { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // Abstract Visitor
    public interface IVisitor
    {
        void Visit(LabelControl control);
        void Visit(TextBoxControl control);
        void Visit(CheckboxControl control);
        void Visit(ButtonControl control);

        string Output { get; }
    }

    // Concrete Visitor
    public class HtmlVisitor : IVisitor
    {
        private StringBuilder builder = new StringBuilder();

        public string Output
        {
            get
            {
                AppendEndDocument();
                return builder.ToString();
            }
        }

        private void AppendEndDocument()
        {
            builder.AppendLine("</html>");
        }

        public HtmlVisitor()
        {
            builder.AppendLine("<html>");
        }

        public void Visit(LabelControl control)
        {
            builder.AppendLine($"<span>{control.Caption}</span>");
        }

        public void Visit(TextBoxControl control)
        {
            builder.AppendLine($"<span>{control.Caption}<input type='text' value='{control.Value}'></input></span>");
        }

        public void Visit(CheckboxControl control)
        {
            builder.AppendLine($"<span>{control.Caption}<input type='checkbox' value='{control.Value}'></input></span>");
        }

        public void Visit(ButtonControl control)
        {
            builder.AppendLine($"<button><img src='{control.ImageSource}'/>{control.Caption}</button>");
        }

    }
}
