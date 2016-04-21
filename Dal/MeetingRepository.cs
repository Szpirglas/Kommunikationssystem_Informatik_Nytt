using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MeetingRepository
    {
        public void sendMeeting(Meeting meeting)
        {
            using (var db = new Entities())
            {

                var newRequest = new Meeting
                {
                    Sender = meeting.Sender,
                    Reciever = meeting.Reciever,
                    Confirmed = meeting.Confirmed,
                    text = meeting.text
                };
                db.Meeting.Add(newRequest);
                db.SaveChanges();
            }

        }
        public void deleteMeeting(int sender, int reciever)
        {
            using (var db = new Entities())
            {
                Meeting x = db.Meeting.FirstOrDefault(y => y.Reciever == reciever && y.Sender == sender);
                // Meeting z = db.Meeting.FirstOrDefault(y => y.Sender == sender && y.Reciever == reciever);
                db.Meeting.Remove(x);
                db.SaveChanges();
            }
        }
        public List<Meeting> requestedList(int id)
        {
            using (var db = new Entities())
            {

                var requests = (from x in db.Meeting
                                where x.Reciever == id && x.Confirmed == false
                                select x);
                var lista = requests.ToList();
                return lista;
            }
        }

        public void acceptRequest(int id)
        {
            using (var db = new Entities())
            {
                var acceptRequest = new Meeting
                {
                    Id = id,
                    Confirmed = true
                };
                db.Meeting.Add(acceptRequest);
                db.SaveChanges();
            }
        }
    }
}