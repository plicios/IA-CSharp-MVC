using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IA_lab6.Models;

namespace IA_lab6.Controllers
{
    public class SongsController : Controller
    {
        private MusicDbContext db = new MusicDbContext();

        private void AssignGenre(Song song)
        {
            song.genre = db.Genres.FirstOrDefault(genre => genre.Id == song.GenreId);
        }

        // GET: Songs
        public ActionResult Index()
        {
            List<Song> songs = db.Songs.ToList();
            foreach(Song song in songs)
            {
                AssignGenre(song);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("songs",songs);
            }
            else
            {
                return View(songs);
            }
            
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            ViewBag.Genres = db.Genres.ToList();
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Artist,GenreId")] Song song)
        {
            ViewBag.Genres = db.Genres.ToList();
            if (ModelState.IsValid)
            {
                //AddSongToGenre(song);

                db.Songs.Add(song);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(song);
        }



        // GET: Songs/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Genres = db.Genres.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Artist,GenreId")] Song song)
        {
            ViewBag.Genres = db.Genres.ToList();
            if (ModelState.IsValid)
            {
                Song removeSong = db.Songs.Find(song.Id);
                //RemoveSongFromGenre(removeSong);

                //AddSongToGenre(song);

                db.Entry(song).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        //[HttpDelete, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Song song = db.Songs.Find(id);

            //RemoveSongFromGenre(song);

            db.Songs.Remove(song);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private void AddSongToGenre(Song song)
        //{
        //    Genre thisSongGenre = db.Genres.FirstOrDefault(genre => genre.Id == song.GenreId);
        //    if (thisSongGenre != null)
        //    {
        //        if (thisSongGenre.Songs != null)
        //        {
        //            thisSongGenre.Songs.Add(song);
        //        }
        //        else
        //        {
        //            thisSongGenre.Songs = new List<Song>() { song };
        //        }
        //    }
        //}

        //private void RemoveSongFromGenre(Song song)
        //{
        //    Genre thisSongGenre = db.Genres.FirstOrDefault(genre => genre.Id == song.GenreId);
        //    if(thisSongGenre?.Songs?.Contains(song) ?? false)
        //    {
        //        thisSongGenre.Songs.Remove(song);
        //    }
        //}
    }
}
