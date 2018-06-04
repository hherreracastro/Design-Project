using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApiNLine.Models;
using ApiNLine.Entities;
using System.Web.Http.Description;

namespace ApiNLine.Controllers
{
    //[Route("game")]
    //[EnableCors(origins:"*", headers:"*", methods:"*")]
    public class GameController : ApiController
    {
        private dbNLineEntities db = new dbNLineEntities();

        /*// GET: api/Game
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET: api/Game/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var boardDb = from b in db.board
                            where b.game == id
                            orderby b.row, b.column
                            select b;

                Board board = new Board(id);
                int lRowIndex = -1;
                Row lActualRow = null;
                foreach(var space in boardDb)
                {
                    if(space.row != lRowIndex)
                    {
                        lRowIndex = space.row;
                        lActualRow = new Row(lRowIndex);
                        board.Rows.Add(lActualRow);
                    }

                    lActualRow.Columns.Add(new Column(space.column,space.chipColor,space.winner));
                }

                return Ok(board);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

       /* // POST: api/Game
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Game/5
        public void Delete(int id)
        {
        }*/
    }
}
