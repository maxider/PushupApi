// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using PushupApi.Data;
// using PushupApi.Models;
//
// namespace Tests.Data;
//
// public class Test_CascadiongInsert {
//     private AsyncUserRepository repository = new AsyncUserRepository(null);
//
//     [Fact]
//     public async Task Foo() {
//         var plan = new PushupPlan() {
//             Days = new List<PushupDay>() {
//                 new PushupDay(.25f, TimeSpan.Zero, false),
//                 new PushupDay(.35f, TimeSpan.Zero, false),
//                 new PushupDay(.45f, TimeSpan.Zero, false),
//             }
//         };
//         var saveUser = await repository.Insert(new User() {
//             CurrentDayInPlan = 1,
//             CurrentPlan      = plan,
//             MaxPushupCount   = 32,
//             Name             = "Kai Uwe"
//         });
//         var get = await repository.GetById(saveUser.ID);
//     }
// }