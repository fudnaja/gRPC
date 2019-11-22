using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ToDoGrpcSerice.Protos;

namespace ToDoGrpcSerice.Services
{
    public class ToDoGrpcService : ToDoService.ToDoServiceBase
    {
        public override Task<ToDoModel> getToDoItem(Empty request, ServerCallContext context)
        {
            return Task.FromResult(GetToDoData());
        }

        public override Task<TestModel> getMessageItem(Empty request, ServerCallContext context)
        {
            return Task.FromResult(GetMessageData());
        }

        public ToDoModel GetToDoData()
        {
            return new ToDoModel()
            {
                Status = true,
                Description = "Test Description",
                Title = "ToDo Title"
            };
        }

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public TestModel GetMessageData()
        {
            Random rnd = new Random();
            StringBuilder text = new StringBuilder();
            int row = rnd.Next(10, 1000);
            for(int r=0;r<row;r++)
            {
                text.Append(RandomString(100) + "\n");
            }
       
            int i = rnd.Next();
            Console.WriteLine("ID: " + i.ToString());
            Console.WriteLine("Message: "+text.ToString());
            return new TestModel()
            {
                ID = i.ToString(),
                Message = text.ToString()
            };
        }
    }
}
