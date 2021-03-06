﻿using SMT_MVCv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMTwebVersion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Translate(string sourceLanguage, string approach)
        {
            PoS_taggingPhase aPostaggingPhase = new PoS_taggingPhase();
            string sentence = aPostaggingPhase.postaggingAND_translation(sourceLanguage, approach);
            return Content(sentence, "text/plain");
        }

    }
}