# OnBirsNoLimitRadio

SCP: Secret Laboratory (EXILED framework) için basit bir telsiz pil tüketim ayarı plugin'i. Telsizlerin pilinin ne kadar hızlı bittiğini tek bir config değeriyle kontrol etmeni sağlar; istersen pili tamamen sınırsız (hiç bitmeyen) hale getirebilirsin.

## Nasıl çalışır?

EXILED'in `Player.UsingRadioBattery` event'ine bağlanır. Bu event, oyunun telsiz pilini her azaltmaya çalıştığı anda (saniyede bir) tetiklenir ve o anki tüketim miktarını (`Drain`) taşır.

- `DrainMultiplier` config değeri `0` (veya negatif) ise: tüketim tamamen iptal edilir (`IsAllowed = false`), pil hiç bitmez.
- `DrainMultiplier` `0`'dan büyükse: o anki tüketim miktarı bu değerle çarpılır (`Drain *= DrainMultiplier`).

Ayar tüm oyunculara ve tüm menzil seviyelerine (SR/MR/LR/UR) eşit şekilde uygulanır; menzile özel ayrı bir değer yoktur.

## Config

Plugin ilk açılışta `~/.config/EXILED/Configs/(port)-config.yml` (Windows: `%AppData%\EXILED\Configs\(port)-config.yml`) dosyasına kendi bölümünü otomatik ekler.

| Alan | Tip | Varsayılan | Açıklama |
| --- | --- | --- | --- |
| `is_enabled` | bool | `true` | Plugin'i açar/kapatır. |
| `debug` | bool | `false` | `true` yapılırsa her pil olayı konsola loglanır. |
| `drain_multiplier` | float | `0` | Pil tüketim çarpanı. `0` = sınırsız pil, `1` = vanilla hız, `0.5` = 2 kat yavaş, `2` = 2 kat hızlı. |

Örnek config çıktısı:

```yaml
on_birs_no_limit_radio:
  is_enabled: true
  debug: false
  drain_multiplier: 0
```

## Gereksinimler

- Güncel EXILED (ExMod-Team fork, NuGet üzerinden `ExMod.Exiled`)
- SCP: Secret Laboratory'nin EXILED'in desteklediği güncel sürümü
- Project Mer çalışan bir sunucu (bu plugin sunucu tarafına özel bir bağımlılık eklemez)

## Derleme

```bash
dotnet build
```

Bu komut `ExMod.Exiled` ve `Exiled.Dev.References` NuGet paketlerini otomatik olarak restore edip projeyi derler. Ayrı bir `lib/` klasörüne veya elle DLL referansına gerek yoktur.

Proje `net48` (.NET Framework 4.8) hedefler — EXILED'in kendisi de bu framework'ü hedeflediği için (`netstandard2.1` değil). `Microsoft.NETFramework.ReferenceAssemblies` paketi sayesinde Visual Studio kurulu olmayan makinelerde de (sadece .NET SDK ile) derlenebilir.

Derleme çıktısı: `bin/Debug/net48/OnBirsNoLimitRadio.dll`

## Kurulum

1. Projeyi derle.
2. Çıkan `OnBirsNoLimitRadio.dll` dosyasını sunucunun EXILED plugin klasörüne kopyala:
   - Windows: `%AppData%\EXILED\Plugins`
   - Linux: `~/.config/EXILED/Plugins`
3. Sunucuyu başlat ya da `reload plugins` komutunu çalıştır.
4. Oluşan config dosyasından `drain_multiplier` değerini istediğin gibi ayarla.

## Notlar

- Bu proje EXILED'in kendisini indirmez; sadece NuGet üzerinden yayınlanan resmi paketlere (ExMod.Exiled, Exiled.Dev.References) referans verir.
- Kod, EXILED'in güncel `master` branch kaynağındaki `UsingRadioBatteryEventArgs`, `Plugin<TConfig>` ve `IConfig` tanımlarına göre yazılmıştır; framework güncellemelerinde bu event'in imzası değişirse plugin'in de güncellenmesi gerekir.
