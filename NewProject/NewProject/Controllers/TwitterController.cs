using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TweetSharp;

namespace NewProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TwitterController : ApiController
    {

        //private RegisterUserContext db = new RegisterUserContext();


        [HttpGet]       
        [Route("api/Twitter")]
        public IHttpActionResult TwitterAuth()
        {
            string Key = "jvy2ZXkqWH6KAPzycTtoMnzgA";
            string Secret = "ApD4fROU3DM8tzdfytZFJOkrQfq0H1Ga6i6yOFH0hXpCgbtntR";

            TwitterService service = new TwitterService(Key, Secret);

           
            OAuthRequestToken requestToken = service.GetRequestToken("http://localhost:55809/api/Twitter/TwitterCallback");

            Uri uri = service.GetAuthenticationUrl(requestToken);
            return Ok(uri.ToString());
            //return Redirect(uri.ToString());
        }

        [HttpGet]
        public IHttpActionResult TwitterCallback(string oauth_token, string oauth_verifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauth_token };
            string Key = "jvy2ZXkqWH6KAPzycTtoMnzgA";
            string Secret = "ApD4fROU3DM8tzdfytZFJOkrQfq0H1Ga6i6yOFH0hXpCgbtntR";

            try
            {
                TwitterService service = new TwitterService(Key, Secret);
                //get Access tocken
                OAuthAccessToken accessToken = service.GetAccessToken(requestToken, oauth_verifier);
                service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);

                //for getting user Profile
                var profile = service.GetUserProfile(new GetUserProfileOptions { IncludeEntities = true });

                VerifyCredentialsOptions option = new VerifyCredentialsOptions();

                TwitterUser user = service.VerifyCredentials(option);
                //TempData["Name"] = user.Name;
                //TempData["Userpic"] = user.ProfileImageUrl;
                //string u= user.Name;
                //return Ok();
                //return Redirect("http://localhost:4200"+u);
                return Redirect("http://localhost:4200");

            }
            catch
            {
                throw;
            }
        }




        //   // POST: api / Twitter
        //   [ResponseType(typeof(TwitterCallback))]
        //    public IHttpActionResult TwitterCallback(twitter tweety)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.twitters.Add(tweety);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = tweety.Id }, tweety);
        //}

    }
    }

