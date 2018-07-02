using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Web.Mvc;
using System.IO;
using System.Drawing.Imaging;
using QRCoder;
using HangmanMVC.Models;


namespace HangmanMVC.Controllers
{
    public class HomeController : Controller
    {
       static Hangman m = new Hangman();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.QRCodeImage = m.GetImage();
            return View(m);
        }
        
        [HttpPost]
        public ActionResult Index(string qrcode)
        {
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //    QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
            //    using (Bitmap bitMap = qrCode.GetGraphic(20))
            //    {
            //        bitMap.Save(ms, ImageFormat.Png);
            //        ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            //    }
            //}
            m.CheckLetter(qrcode[0]);
            ViewBag.QRCodeImage = m.GetImage();
            return View("Index", m);

        }


    }
}