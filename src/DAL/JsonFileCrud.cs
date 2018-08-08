using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using DAL.model;

namespace DAL
{
    public class JsonFileCrud : IJsonFileCrud
    {
#region prop

        public string JsonDbPath { get; private set; }
#endregion

#region ctor
        public JsonFileCrud(string filePath)
        {
            JsonDbPath = filePath;
        }
        #endregion

        #region Func

        #region public
        public GameResponse GetAll()
        {
            GameResponse gm = null;
            var json = ReadFile();

            if (json != null)
            {
                gm = GameResponse.FromJson(json);
            }

            return gm;
        }

        public bool Add(ref Game newGame)
        {
            GameResponse gm = null;
            gm = GetAll();

            newGame.GameId = gm.Games.Count + 1;
            newGame.Id = Guid.NewGuid().ToString().Replace("-", "");

            gm?.Games.Add(newGame);
            string json = gm.ToJson();

            try
            {
                File.WriteAllText(JsonDbPath, json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Game newGame)
        {
            GameResponse gm = null;
            gm = GetAll();

            try
            {
                var res = gm.Games.Find(x => x.Id == newGame.Id);
                if (res != null)
                {
                    res.Description = newGame.Description;
                    res.IsActive = newGame.IsActive;
                    res.Picture = newGame.Picture;
                    res.Size = newGame.Size;
                    res.Title = newGame.Title;
                    res.Selected = newGame.Selected;
                    res.TorrentUrl = newGame.TorrentUrl;

                    string json = gm.ToJson();
                    File.WriteAllText(JsonDbPath, json);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
               return false;
            }

        }

        public bool Delete(string id)
        {
            GameResponse gm = null;
            gm = GetAll();
            int res = gm.Games.RemoveAll(x => x.Id == id);
            if (res != 0)
            {

                string json = gm.ToJson();
                File.WriteAllText(JsonDbPath, json);

                return true;
            }
            else
            {
                return false;
            }
            
        }

        #endregion 

        #region private
        private string ReadFile()
        {
            string fileText = null;
            try
            {
                fileText = File.ReadAllText(JsonDbPath);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return fileText;
        }

        #endregion  
        #endregion
    }
}
