using DemoCyberSecurite.Api.Bll.Entities;
using DemoCyberSecurite.Api.Bll.Repositories;
using DemoCyberSecurite.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DemoCyberSecurite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Enregistrer")]
        public IActionResult Enregistrer([FromBody] EnregistrementUtilisateurDto dto)
        {
            try
            {
                _authRepository.Register(new Utilisateur(dto.Nom, dto.Prenom, dto.Email, dto.Passwd));
                return NoContent();
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(new { ex.Message });
#else
                return BadRequest();
#endif
            }
        }

        [HttpPost("Authentifier")]
        public IActionResult Authentifier([FromBody] AuthentifierUtilisateurDto dto)
        {
            try
            {
                Utilisateur? utilisateur = _authRepository.Login(dto.Email, dto.Passwd);

                if (utilisateur is null)
                {
                    return NotFound();
                }
                return Ok(new UtilisateurDto(utilisateur));
            }
            catch (Exception ex)
            {
#if DEBUG
                return BadRequest(new { ex.Message });
#else
                return BadRequest();
#endif
            }
        }
    }
}
