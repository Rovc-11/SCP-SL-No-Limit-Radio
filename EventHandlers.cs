// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="William">
// Copyright (c) William. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace OnBirsNoLimitRadio
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Player;

    /// <summary>
    /// Telsiz pil olaylarını yöneten sınıf.
    /// </summary>
    public class EventHandlers
    {
        private readonly Config config;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="config">Ana plugin'in config nesnesi.</param>
        public EventHandlers(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// <see cref="Exiled.Events.Handlers.Player.UsingRadioBattery"/> event'ini işler.
        /// Telsizin pil tüketimini config'teki çarpana göre yavaşlatır ya da tamamen durdurur.
        /// </summary>
        /// <param name="ev">Event verileri.</param>
        public void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev)
        {
            // 0 veya daha küçük bir değer = pil hiç tükenmesin (sınırsız şarj).
            if (config.DrainMultiplier <= 0f)
            {
                ev.IsAllowed = false;

                if (config.Debug)
                    Log.Debug($"[OnBirsNoLimitRadio] {ev.Player.Nickname} telsizinin pil tüketimi engellendi (sınırsız mod).");

                return;
            }

            // Aksi halde, orijinal tüketim değerini (saniye başına drain) çarpanla ölçekle.
            float original = ev.Drain;
            ev.Drain *= config.DrainMultiplier;

            if (config.Debug)
                Log.Debug($"[OnBirsNoLimitRadio] {ev.Player.Nickname} için pil tüketimi {original} -> {ev.Drain} olarak ayarlandı (çarpan: {config.DrainMultiplier}).");
        }
    }
}
