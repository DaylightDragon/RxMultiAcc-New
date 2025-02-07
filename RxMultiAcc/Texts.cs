using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RbxMultiAcc {
    internal class Texts {
        public static CultureInfo culture = CultureInfo.CurrentCulture;

        public static string TranslateMessageCouldntCreateMutex() {
            switch (culture.TwoLetterISOLanguageName) {
                case "ru":
                    return "[Ошибка] Не удалось выполнить задачу. Либо эта программа уже запущена (ранее не выводила этой ошибки), " +
                        "либо процесс игры прямо сейчас запущен, чего быть не должно.\n" +
                        "\n" +
                        "Это окно пропадёт через 5 секунд";
                default:
                    return "[Error] Couldn't perform the task. Either an another instance of this application is already running " +
                        "or a game instance process is currently running.\n" +
                        "\n" +
                        "This window will dissapear in 5 seconds";
            }
        }

        public static string TranslateMessageSuccessfullyCreatedMutex() {
            switch (culture.TwoLetterISOLanguageName) {
                case "ru":
                    return "[Инф] Успешно создан мьютекс, теперь у вас должно получаться запускать несколько сессий игры сразу.";
                default:
                    return "[Info] Successfully created the mutex, now you should be able to launch multiple game instances at a time.";
            }
        }
    }
}
