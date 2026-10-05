"""UserPromptSubmit-hook: lägger till varje prompt ordagrant sist i prompt_history.md.

Claude fyller sedan i raden "**Resultat:**" när svaret är klart (se CLAUDE.md).
"""
import json
import os
import re
import sys

PLACEHOLDER = "**Resultat:** _(fylls i av Claude)_"

data = json.loads(sys.stdin.buffer.read().decode("utf-8"))
prompt = data.get("prompt", "")
# Ta bort kontext som VS Code lägger till automatiskt, t.ex. <ide_opened_file>...</ide_opened_file>
prompt = re.sub(r"<(ide_[a-z_]+|system-reminder)>.*?</\1>", "", prompt, flags=re.DOTALL).strip()
if not prompt:
    sys.exit(0)

project_dir = os.environ.get("CLAUDE_PROJECT_DIR") or data.get("cwd") or os.getcwd()
path = os.path.join(project_dir, "prompt_history.md")

existing = ""
if os.path.exists(path):
    with open(path, encoding="utf-8") as f:
        existing = f.read()

numbers = [int(n) for n in re.findall(r"^### (\d+)\s*$", existing, re.MULTILINE)]
next_number = max(numbers, default=0) + 1

quoted = "\n".join("> " + line if line else ">" for line in prompt.splitlines())
entry = f"\n### {next_number}\n{quoted}\n\n{PLACEHOLDER}\n"

with open(path, "a", encoding="utf-8", newline="\n") as f:
    if existing and not existing.endswith("\n"):
        f.write("\n")
    f.write(entry)
