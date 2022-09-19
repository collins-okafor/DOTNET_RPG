using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Character;
using api.Models;
using AutoMapper;

namespace api.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character {Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            return characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        }

        public async Task<List<GetCharacterDto>> DeleteCharacter(int id)
        {
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);
                characters.Remove(character);
                return characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<GetCharacterDto>> GetAllCharacter()
        {
            return characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        }

        public async Task<GetCharacterDto> GetCharacterById(int id)
        {
            return _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
        }

        public async Task<List<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.Strength;
                character.Defence = updatedCharacter.Defence;
                character.Intelligence = updatedCharacter.Intelligence;
                character.Class = updatedCharacter.Class;

                return characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
