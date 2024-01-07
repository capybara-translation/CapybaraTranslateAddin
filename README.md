# Capybara Translate Addin

https://github.com/capybara-translation/CapybaraTranslateAddin/assets/9638290/5706483b-d566-4044-9c57-e1c309eb5435

## Overview (ja)
Excelから機械翻訳APIとText-to-Speech APIを呼び出せるアドインです。主にAnkiカード作成を効率化するために開発しましたが、Ankiユーザー以外の方にも便利かもしれません。
機械翻訳APIについては、現在下記のサービスに対応しています。

- Google Cloud Translation API V2
- DeepL API
- OpenAI API (gpt-4)

Text-to-Speech APIについては、現在下記のサービスに対応しています。

- Google Text-to-Speech API V1

## Overview (en)
Capybara Translate Addin is an Excel addin that allows you to call the APIs of major machine translation services and text-to-speech services.
Machine translation services currently available include:

- Google Cloud Translation API V2
- DeepL API
- OpenAI API (gpt-4)

Text-to-speech services currently available include:

- Google Text-to-Speech API V1

## How to use Capybara Translate Addin (ja)

[Releaseページ](https://github.com/capybara-translation/CapybaraTranslateAddin/releases)にインストーラーを公開していますので、そちらからダウンロードしてください。

また、このアドインを使用するには、上記サービスのAPIキー (Googleについてはサービスアカウントキー) を事前に取得しておく必要があります。
APIキーまたはサービスアカウントキーを取得したら、アドインのSettingsダイアログに入力します。Settingsダイアログは、リボンのCapybara Translateタブ > Preferences > Settingsをクリックすると表示されます。
各サービスのAPIキーを対応するフィールドに入力しOKボタンをクリックしてダイアログを閉じます。

## How to use Capybara Translate Addin (en)

You can download the installer from the [Release page](https://github.com/capybara-translation/CapybaraTranslateAddin/releases).
You need to obtain API keys for the services mentioned above (a service account key for Google) before using this addin. After obtaining the API keys, install the addin, launch Excel, and click Capybara Translate tab > Preferences > Settings to display the Settings dialog. In the Settings dialog, enter the API keys in the corresponding text fields and click the OK button to apply the changes.

