# Platformer Example
Точкой входа является скрипт **MainEntryPoint** на сцене **Main**. Данная сцена нужна для максимально быстрого запуска приложения. Далее, из нее осуществляется переход на сцену **Core** и активируется скрипт **CoreEntryPoint**, запускающий основной игровой цикл.

Игровой процесс контролируется в рамках менеджеров:
- **AttachmentManager** - для прикреплений;
- **CoinManager** - для монет;
- **CollisionManager** - для коллизий (**Player** / **Trigger**);
- **InputManager** - для ввода;
- **ModifierManager** - для модификаций (активация / деактивация бонусов).

Весь мир представлен в виде динамически генерируемых регионов (**Region**). За их создание / удаление отвечает **RegionController**. Обновление регионов осуществляется в момент попадания игрока в триггер **UpdateTrigger**.

В мире встречаются сущности:
- **Enemy** - противник (препятствие). При столкновении с ним отнимаются монеты;
- **Item** - предмет (монеты, бонусы и тд). Каждый предмет может содержать список из прикреплений (**Attachment**), активирующих специфичную логику при подборе;
- **Player** - игрок.

Прикрепление наследует интерфейс **IAttachment**. Помимо прикрепления тажке необходимо реализовать и зарегистрировать обработчик, наследуемый от **IAttachmentHandler**. Все обработчики регистрируются в **AttachmentManager**. Схема вызовов: **IAttachment -> AttachmentManager -> IAttachmentHandler**.

Модификатор наследует интерфейс **IModifier**. Он отвечает за изменение игрового поведения и обрабатывается в рамках **ModifierManager**.

Пример работы бонуса ускорения:
- Игрок подбирает предмет;
- Из предмета извлекается прикрепление **VelocityAttachment** и активируется через **AttachmentManager**;
- В рамках **VelocityAttachmentHandler** создается модификатор **VellocityModifier** и активируется через **ModifierManager**.

## Plugins
- R3 (https://github.com/Cysharp/R3)
    - CoinManager
    - HudModel
    - HudViewModel
- UniTask (https://github.com/Cysharp/UniTask)
    - MainEntryPoint
- VContainer (https://github.com/hadashiA/VContainer)
    - MainEntryPoint
    - MainLifetimeScope
    - CoreEntryPoint
    - CoreLifetimeScope

## Patterns
- Dependency Injection
- MVVM
    - HudModel
    - HudView
    - HudViewModel
- Object Pool
    - RegionPool