using System.Collections.Generic;
using System.Web.Mvc;
using RobotArmy.Core.Helpers;
using RobotArmy.Core.Model;
using RobotArmy.Core.Repositories;

namespace RobotArmy.Web.Controllers
{
    public class RobotController : SmartController  
    {
        
        // GET:   /Robot/List
        public ActionResult List() 
        {
            // TODO implementation
            return View();
        }





        //
        // GET: /Robot/Details/5

        public ActionResult Details(int id)
        {
            // TODO implementation
            return View();
        }



       

        public ActionResult Edit(int id)
        {
            // TODO implementation
            return View();
        }


        #region Edit(plain Robot)

//        [AcceptVerbs(HttpVerbs.Post)]
//        [Transaction]
//        public ActionResult Edit(Robot robot)
//        {
//            robotRepository.Save(robot);
//            return RedirectToAction<RobotController>(c => c.List());
//        }
        


        #region Secret Stuff
        //public ActionResult Edit([ModelBinder(typeof(RobotBinder))] Robot robot)
//[ValidateAntiForgeryToken] 
        //<%= Html.AntiForgeryToken() %>
        #endregion

        #endregion


        #region Edit(RobotView)
        
        #region Binding Alternatives
/* some different options for binding:
 *    http://www.codethinked.com/post/2009/01/08/ASPNET-MVC-Think-Before-You-Bind.aspx
 * 
 * 1] use FormCollection and do it yourself 
 *      (very ugly, magic strings - and is easy to mess up)
 *      
 * 2] Pass in all the individual pieces yourself
 *      (very ugly, strings with a little less magic 
 *              - and is easy to mess up)
 *      
 * 3] use UpdateModel() and specify exactly what to
 *      bind in a given situation:
 *      UpdateModel(robot, new[] { "Id", "Name" });
 *      
 * 4] use UpdateModel() vs an interface to control binding.
 *      UpdateModel<IRobotFormBindable>(robot, "robot");
 *      
 * 5] create your own ModelBinder 
 *      a) declare globally in global.asax.cs
 *          -- applies to ALL Robot parameters...
 *          
 *      b) declare for an action:
 *          public ActionResult Edit([ModelBinder(typeof(RobotBinder))] Robot robot)
 *                   
 * 
 * 6]  Create a View-Model object, presentation-only model
 *      Then you translate from the real Model into 
 *      the ViewModel, and back.
 *      For many situations, this is the best choice.
 */
        #endregion

//        [AcceptVerbs(HttpVerbs.Post)]
//        [Transaction]
        ////        [ValidateAntiForgeryToken] // Prevent CSRF (Cross Site Request Forgery)
//        public ActionResult Edit(RobotView robot)
//        {
//            var realRobot = robotRepository.Get(robot.Id);
//            if (realRobot != null)
//            {
//                realRobot.Name = robot.Name;
//                robotRepository.Save(realRobot);
//            }
//            return RedirectToAction<RobotController>(c => c.List());
//        }

        #endregion



        #region /Robot/Create
        //
        // GET: /Robot/Create

        public ActionResult Create()
        {
            return View();
        }

        
        //
        // POST: /Robot/Create
        

//        [AcceptVerbs(HttpVerbs.Post)]   // accepts POST only
//        [Transaction]                   // a filter
//        [ValidateAntiForgeryToken]      // Prevent CSRF (Cross Site Request Forgery)
//        public ActionResult Create(Robot robot)
//        {
//            robotRepository.Save(robot);
//            return RedirectToAction<RobotController>(c => c.List());
//        }
         
        #endregion




    }



    #region public  class RobotView { ... }
    public class RobotView
    {
        public int Id { get; set;}
        public string Name { get; set; }
    }
    #endregion
}
