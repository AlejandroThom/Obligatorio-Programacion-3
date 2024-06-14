﻿using DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiObligatorioP3.Token
{
    public class ManejadorToken
    {
        internal static string CrearToken(UsuarioLoginRetornoDTO dto)
        {

            byte[] clave = Encoding.ASCII.GetBytes("ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=");

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, generalmente se incluye en el archivo de configuración
            //Debe ser un vector de bytes         

            //Se incluye un claim para el email
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, dto.Email),
                    new Claim(ClaimTypes.Role, dto.Rol),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
