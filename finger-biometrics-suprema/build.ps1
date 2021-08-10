# Path para onde vai a build criada
# -o dist
# O -c Release parâmetro não é obrigatório. Ele é fornecido como um lembrete para publicar a compilação de versão do seu aplicativo.
# -c Release
# programa autocontido, não precisa ter nada na máquina instalado como pré-requisito
# --self-contained true
# runtime escolhido para o build autocontido com o respectivo RIDS https://docs.microsoft.com/pt-br/dotnet/core/rid-catalog
# -r win7-x64
# saída em arquivo único de executável 
# /p:PublishSingleFile=true

# dotnet publish -c Release -o dist --self-contained true -r win10-x64 /p:PublishSingleFile=true
dotnet publish -c Release -o dist --self-contained true -r win7-x64 /p:PublishSingleFile=true
