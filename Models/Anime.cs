﻿using Almanime.Models.Enums;

namespace Almanime.Models;

public class Anime : Base
{
    public Anime(
        int kitsuID,
        string slug,
        string name,
        ESeason season,
        EAnimeStatus status,
        DateTime startDate,
        DateTime? endDate,
        string? synopsis,
        SizedImage? coverImages,
        SizedImage? posterImages
    ) : this(kitsuID, slug, name, season, status, startDate, endDate, synopsis)
    {
        CoverImages = coverImages;
        PosterImages = posterImages;
    }

    protected Anime(
        int kitsuID,
        string slug,
        string name,
        ESeason season,
        EAnimeStatus status,
        DateTime startDate,
        DateTime? endDate,
        string? synopsis
    )
    {
        KitsuID = kitsuID;
        Slug = slug ?? throw new ArgumentNullException(nameof(slug));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Season = season;
        Status = status;
        StartDate = startDate;
        EndDate = endDate;
        Synopsis = synopsis;
    }

    public int KitsuID { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public ESeason Season { get; set; }
    public EAnimeStatus Status { get; set; }
    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }
    public string? Synopsis { get; set; }
    public SizedImage? CoverImages { get; set; }
    public SizedImage? PosterImages { get; set; }

    public virtual ICollection<Episode> Episodes { get; set; } = default!;
}
