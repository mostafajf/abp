using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace abp_ms_test.PublicWeb;

[Dependency(ReplaceServices = true)]
public class abp_ms_testBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "abp_ms_test";
}
