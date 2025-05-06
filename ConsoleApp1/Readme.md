# OldPhoneChallenge
Oldphone Emulator - > imitates sequence of keypresses from an old phone keypad to letters.

Pressing the same number cycles through its letters.

A space " " is required to pause before repeating characters from the same button.

"*" acts as a backspace.

"#" marks the end of the input and is required.

"0" is used as space sentences.

Invalid keys like 1, or too many presses, are ignored or wrapped modulo the letter length.



| Input                  | Output  |
| ---------------------- | ------- |
| `"33#"`                | `E`     |
| `"227*#"`              | `B`     |
| `"4433555 555666#"`    | `HELLO` |
| `"8 88777444666*664#"` | `THINE` |
