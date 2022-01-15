﻿using Almanime.Models;
using Almanime.Models.DTO;

namespace Almanime.Utils.Mappers;

public static class FansubMapper
{
    public static Fansub MapToModel(this FansubDTO fansubDTO)
    {
        var isWebpageAnUri = Uri.TryCreate(fansubDTO.Webpage, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

        if (fansubDTO.Webpage != null && !isWebpageAnUri) throw new ArgumentNullException(nameof(fansubDTO), "The value of 'fansubDTO.Webpage' is not a valid Uri");

        return new(
            acronym: fansubDTO.Acronym ?? throw new ArgumentNullException(nameof(fansubDTO), "The value of 'fansubDTO.Acronym' should not be null"),
            name: fansubDTO.Name ?? throw new ArgumentNullException(nameof(fansubDTO), "The value of 'fansubDTO.Name' should not be null"),
            webpage: fansubDTO.Webpage
        );
    }
}
