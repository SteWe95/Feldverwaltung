using System;

namespace Feldverwaltung.Auftragsliste
{
    public class ViewModelBase
    {
        public Controller controller { get; }

        public ViewModelBase(Controller controller)
        {
            this.controller = controller;
        }

        public string GetExceptionMessages(Exception e, string messages = "")
        {
            if (e == null) return string.Empty;
            if (messages == "") messages = e.Message;
            if (e.InnerException != null)
                messages += "\r\n" + GetExceptionMessages(e.InnerException);
            return messages;
        }
    }
}