using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaseForTheAges.Models
{
    public class MessagesDbInitializer: DropCreateDatabaseAlways<MessagesContext>
    {
        protected override void Seed(MessagesContext db)
        {
            db.Messages.Add(new Message { MessageText = "Война и мир", Author = "Л. Толстой", Topic = 220 });
            db.Messages.Add(new Message { MessageText = "Отцы и дети", Author = "И. Тургенев", Topic = 180 });
            db.Messages.Add(new Message { MessageText = "Чайка", Author = "А. Чехов", Topic = 150 });

            base.Seed(db);
        }
    }
}