namespace Day10;

public class Machine(bool[] targetLights, HashSet<int[]> buttons, int[] joltage, int id)
{
    public int Id = id;
    public bool[] TargetLights = targetLights;
    public HashSet<int[]> Buttons = buttons;
    public int[] Joltage = joltage;

    public static Machine FromInputString(string input, int index)
    {
        var parts = input.Split(' ');

        bool[] targetLights = [.. parts[0].Where(c => c == '.' || c == '#').Select(c => c == '#')];
        HashSet<int[]> buttons = GetButtonsFromInputString(parts[1..^1]);
        int[] joltages = [.. parts[^1][1..^1].Split(',').Select(int.Parse)];

        return new Machine(targetLights, buttons, joltages, index);
    }

    public int TryToSolveMachinePart1()
    {
        var initialState = new bool[TargetLights.Length];
        var visited = new HashSet<bool[]>();
        var queue = new Queue<(bool[] State, int Presses)>([(State: initialState, Presses: 0)]);

        while (queue.Count > 0)
        {
            var (state, presses) = queue.Dequeue();
            if (IsCorrectTargetLight(state))
            {
                return presses;
            }

            foreach (var button in Buttons)
            {
                var newState = ToggleButton(button, state);
                if (visited.Add(newState))
                {
                    queue.Enqueue((newState, presses + 1));
                }
            }
        }

        return 0;
    }

    public int TryToSolveMachinePart2()
    {
        var initialState = new int[Joltage.Length];
        var visited = new HashSet<int[]>();
        var queue = new Queue<(int[] State, int Presses)>([(State: initialState, Presses: 0)]);

        while (queue.Count > 0)
        {
            var (state, presses) = queue.Dequeue();
            if (IsCorrectJoltage(state))
            {
                return presses;
            }

            if (IsOverJoltage(state))
            {
                continue;
            }

            foreach (var button in Buttons)
            {
                var newState = ToggleSwitch(button, state);
                if (visited.Add(newState))
                {
                    queue.Enqueue((newState, presses + 1));
                }
            }
        }

        return 0;
    }

    private static int[] ToggleSwitch(int[] button, int[] state)
    {
        int[] newState = new int[state.Length];
        Array.Copy(state, newState, state.Length);

        for (int i = 0; i < button.Length; i++)
        {
            newState[button[i]] = newState[button[i]] + 1;
        }
        return newState;
    }

    public static bool[] ToggleButton(int[] button, bool[] state)
    {
        bool[] newState = new bool[state.Length];
        Array.Copy(state, newState, state.Length);

        for (int i = 0; i < button.Length; i++)
        {
            newState[button[i]] = !state[button[i]];
        }
        return newState;
    }

    private static HashSet<int[]> GetButtonsFromInputString(string[] inputStrings)
    {
        var buttons = new HashSet<int[]>();

        for (var i = 0; i < inputStrings.Length; i++)
        {
            var button = inputStrings[i][1..^1].Split(',').Select(int.Parse).ToArray();
            buttons.Add(button);
        }

        return buttons;
    }

    private bool IsCorrectTargetLight(bool[] state)
    {
        for (int i = 0; i < TargetLights.Length; i++)
        {
            if (targetLights[i] != state[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool IsCorrectJoltage(int[] state)
    {
        for (int i = 0; i < Joltage.Length; i++)
        {
            if (Joltage[i] != state[i])
            {
                return false;
            }
        }

        return true;
    }

    private bool IsOverJoltage(int[] state)
    {
        for (int i = 0; i < Joltage.Length; i++)
        {
            if (Joltage[i] < state[i])
            {
                return true;
            }
        }

        return false;
    }
}
