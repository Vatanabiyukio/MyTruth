using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace SortOnDemilich.Models;

public class ResponseApi
{
    public Guid Id => Guid.NewGuid();
    public bool Success { get; init; }
    public object? Data { get; init; }
    public object? Error { get; init; }
    public DateTime CreatedAt => DateTime.Now;
}