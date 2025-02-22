﻿using TouristApp.Blazor.Exceptions;
using TouristApp.Domain.Models.Coordinate;

namespace TouristApp.Web.Services.GeoLocationBroker;

public interface IGeoLocationBroker {
    public Coordinate Coordinates { get; }
    public ValueTask RequestGeoLocationAsync(bool enableHighAccuracy, int maximumAgeInMilliseconds);

    public ValueTask RequestGeoLocationAsync();

    public Task OnSuccessAsync(Coordinate coordinates);

    public Task OnErrorAsync(GeolocationPositionError error);

    public event Func<Coordinate, ValueTask> CoordinatesChanged;
    public event Func<GeolocationPositionError, ValueTask> OnGeolocationPositionError;
}