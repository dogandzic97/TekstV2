using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TekstV2.Models;

namespace TekstV2.Controllers
{
    public class HomeController : Controller
    {
        public BazaPropisaContext _context = new BazaPropisaContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_context.Propis.ToList());
        }
        [HttpGet]
        public ActionResult UnesiTekst(int id) 
        {
            return View(_context.Propis.Find(id));
        }

        [HttpPost]
        public ActionResult UnesiTekst(int id, IFormCollection collection)
        {
            Propis p = (from pr in _context.Propis
                        where pr.Id == id
                        select pr).Single();
            p.TekstPropisa = collection["TekstPropisa"];
            try
            {
                _context.SaveChanges();
                RazdeliTekst(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
       }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart))
            {
                string string1 = strSource;
                string toFind1 = strStart;
                string toFind2 =strEnd;
                int start = strSource.IndexOf(toFind1) + toFind1.Length;
                int end = strSource.IndexOf(toFind2, start);
                string string2 = strSource.Substring(start, end - start);
                return string2;
            }

            return "";
        }

        public void RazdeliTekst(Propis propis)
        {
            int brojacClanova = 1;
            
            while(brojacClanova<5)
            {
                string clanPatern = "<p style=\"margin: 0in 0in 6pt; text-align: center; line-height: 115%; font-size: 11pt; font-family: Verdana, sans-serif;\"><span style=\"color: black;\">Члан "+brojacClanova+".</span></p>";
              //  string tekst= " <p style="margin: 0in 0in 6pt; text - align: center; line - height: 115 %; font - size: 11pt; font - family: Verdana, sans - serif; "><span style="color: black; ">Члан 1.</span></p> <p style="margin: 0in 0in 7.5pt; line - height: 115 %; font - size: 11pt; font - family: Verdana, sans - serif; "><span style="color: black; ">aNDJEHSEJAHGFUYASGFJHBCJHGSDFJGAJHSDFGJAHSDGFJKHGKIJHGhgsjahdgjshdfgjkhsfgjhgvbjhgsakjdhfgajhksdfgjhsgfjhsagdfjhsagdfjhgnmbjhgsadf</span></p>"
                propis.TekstPropisa.Replace("\"", "'");
                clanPatern.Replace("\"", "'");
                if (propis.TekstPropisa.Contains(clanPatern))
                {
                    Clan c = new Clan();
                    c.IdPropis = propis.Id;
                    c.Naziv = "Члан " + brojacClanova + ".";
                    try
                    {
                        _context.Clan.Add(c);
                        _context.SaveChanges();
                    }
                    catch
                    {
                        throw;
                    }
                    brojacClanova += 1;
                    int clanId = (from cl in _context.Clan
                                 select cl.Id).Max();
                   // Regex reg=new Regex(@"^(<p style=\'margin: 0in 0in 7\.5pt; line - height: 115 %; font - size: 11pt; font - family: Verdana, sans - serif;\'><span style=\'color: black;\'>){1}\W{1}\w+(</span></p>){1}$");
                    string stavPatern = "<p style=\"margin: 0in 0in 6pt; text-align: center; line-height: 115%; font-size: 11pt; font-family: Verdana, sans-serif;\"><span style=\"color: black;\">Члан " + brojacClanova + ".</span></p>\r\n <p style=\"margin: 0in 0in 7.5pt; line-height: 115%; font-size: 11pt; font-family: Verdana, sans-serif;\"><span style=\"color: black;\">";
                    stavPatern.Replace("\"", "'");
                    if (propis.TekstPropisa.Contains(clanPatern)) {
                        int brojacStavova = 1;

                        Stav stav = new Stav();
                        stav.Naziv = "Став " + brojacStavova;
                        brojacStavova += 1;

                        stav.IdClan = clanId;

                        string source = propis.TekstPropisa;
                        int start = propis.TekstPropisa.IndexOf(stavPatern) + stavPatern.Length;
                        int end = propis.TekstPropisa.IndexOf("</span></p>", start);
                        string string2 = propis.TekstPropisa.Substring(start, end - start);
                        stav.Tekst = string2;
                        try
                        {
                            _context.Stav.Add(stav);
                            _context.SaveChanges();
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }

            }

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
