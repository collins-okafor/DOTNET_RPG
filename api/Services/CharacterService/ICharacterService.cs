using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Character;
using api.Models;

namespace api.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<List<GetCharacterDto>> GetAllCharacter();
        Task<GetCharacterDto> GetCharacterById(int id);
        Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter);
        Task<List<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<List<GetCharacterDto>> DeleteCharacter(int id);
    }
}