// -----------------------------------------------------------------------
// <copyright file="OnBirsNoLimitRadioPlugin.cs" company="William">
// Copyright (c) William. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace OnBirsNoLimitRadio
{
    using System;

    using Exiled.API.Features;

    using Player = Exiled.Events.Handlers.Player;

    /// <summary>
    /// Telsiz pil tüketim hızını yavaşlatan/sınırsız yapan EXILED plugin'i.
    /// </summary>
    public class OnBirsNoLimitRadioPlugin : Plugin<Config>
    {
        /// <inheritdoc/>
        public override string Name { get; } = "OnBirsNoLimitRadio";

        /// <inheritdoc/>
        public override string Author { get; } = "William";

        /// <inheritdoc/>
        public override Version Version { get; } = new(1, 0, 0);

        /// <summary>
        /// Gets the event handler instance for this plugin.
        /// </summary>
        public EventHandlers EventHandlers { get; private set; }

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            EventHandlers = new EventHandlers(Config);
            Player.UsingRadioBattery += EventHandlers.OnUsingRadioBattery;

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Player.UsingRadioBattery -= EventHandlers.OnUsingRadioBattery;
            EventHandlers = null;

            base.OnDisabled();
        }
    }
}
