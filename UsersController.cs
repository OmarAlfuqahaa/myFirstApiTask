using apiTask.models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> Users = new List<User>
        {
            new User(1, "Omar", "Alfoqahaa", new DateTime(1990, 1, 1), "alfoqahaaomar@gmail.com"),
            new User(2, "Amer", "Alfoqahaa", new DateTime(1992, 2, 2), "aloqahaaamer.com")
        };

        // get all users 
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(Users);
        }

        // get user by id
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            User foundUser = null;

            foreach (var user in Users)
            {
                if (user.id == id)
                {
                    foundUser = user;
                    break;
                }
            }

            if (foundUser == null)
            {
                return NotFound();
            }

            return Ok(foundUser);
        }


        // add user 
        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            int maxId = 0;

            // find the maximum id
            foreach (var user in Users)
            {
                if (user.id > maxId)
                {
                    maxId = user.id;
                }
            }

            
            newUser.id = maxId + 1;

            Users.Add(newUser);

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.id }, newUser);
        }


        // update user 
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            User user = null;

            
            foreach (var u in Users)
            {
                if (u.id == id)
                {
                    user = u;
                    break;
                }
            }

            if (user == null)
            {
                return NotFound();
            }

            
            user.firstName = updatedUser.firstName;
            user.lastName = updatedUser.lastName;
            user.dateOfBirth = updatedUser.dateOfBirth;
            user.email = updatedUser.email;

            return NoContent();
        }


        // delete user by id
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User userToDelete = null;

            
            foreach (var user in Users)
            {
                if (user.id == id)
                {
                    userToDelete = user;
                    break;
                }
            }

            if (userToDelete == null)
            {
                return NotFound();
            }

         
            Users.Remove(userToDelete);

            return NoContent();
        }

    }
}
