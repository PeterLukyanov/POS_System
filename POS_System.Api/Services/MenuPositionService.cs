using CSharpFunctionalExtensions;

using Dtos;
using Models;
using Db;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class MenuPositionService
{
    private readonly POS_System_Db db;
    public MenuPositionService(POS_System_Db _db)
    {
        db = _db;
    }
    public async Task<Result<MenuPosition>> AddNewMenuPosition(MenuPositionForCreateDto dto)
    {
        var listOfMenuPositions = await db.MenuPositions.Select(p => p.Name).ToListAsync();
        foreach (var menuPositionName in listOfMenuPositions)
        {
            if (dto.Name.Trim().ToLower() == menuPositionName.Trim().ToLower())
            {
                return Result.Failure<MenuPosition>("There is already such a name");
            }
        }

        var menuPosition = new MenuPosition(dto.Name, dto.Description, dto.Cost, TimeSpan.FromMinutes(dto.TimeOfPreparation));
        await db.MenuPositions.AddAsync(menuPosition);
        await db.SaveChangesAsync();
        return Result.Success(menuPosition);
    }

    public async Task<Result<List<MenuPosition>>> ShowAllMenuPositions()
    {
        var listOfMenuPositions = await db.MenuPositions.ToListAsync();
        if (listOfMenuPositions.Count == 0)
        {
            return Result.Failure<List<MenuPosition>>("There are no menu positions yet");
        }
        else
            return Result.Success(listOfMenuPositions);
    }

    public async Task<Result<MenuPosition>> ShowMenuPosition(string name)
    {
        var listOfMenuPositions = await db.MenuPositions.ToListAsync();
        if (listOfMenuPositions.Count == 0)
        {
            return Result.Failure<MenuPosition>("There are no menu positions yet");
        }
        else if (listOfMenuPositions.FirstOrDefault(p => p.Name == name) == null)
            return Result.Failure<MenuPosition>("There are no such menu position");
        else
            return Result.Success(listOfMenuPositions.First(p => p.Name == name));
    }

    public async Task<Result<MenuPosition>> UpdateMenuPosition(MenuPositionForCreateDto dto)
    {
        var listOfMenuPositions = await db.MenuPositions.ToListAsync();
        if (listOfMenuPositions.Count == 0)
        {
            return Result.Failure<MenuPosition>("There are no menu positions yet");
        }
        else if (listOfMenuPositions.FirstOrDefault(p => p.Name == dto.Name) == null)
            return Result.Failure<MenuPosition>("There are no such menu position");
        else
        {
            var menuPosition = listOfMenuPositions.First(p => p.Name == dto.Name);
            menuPosition.SetName(dto.Name);
            menuPosition.SetDescription(dto.Description);
            menuPosition.SetCost(dto.Cost);
            menuPosition.SetTimeOfPreparation(TimeSpan.FromMinutes(dto.TimeOfPreparation));
            await db.SaveChangesAsync();
            return Result.Success(menuPosition);
        }
    }

    public async Task<Result<MenuPosition>> DeleteMenuPosition(string name)
    {
        var listOfMenuPositions = await db.MenuPositions.ToListAsync();
        if (listOfMenuPositions.Count == 0)
        {
            return Result.Failure<MenuPosition>("There are no menu positions yet");
        }
        else if (listOfMenuPositions.FirstOrDefault(p => p.Name == name) == null)
            return Result.Failure<MenuPosition>("There are no such menu position");
        else
        {
            var menuPosition = listOfMenuPositions.First(p => p.Name == name);
            db.MenuPositions.Remove(menuPosition);
            await db.SaveChangesAsync();
            return Result.Success(menuPosition);
        }
    }
}