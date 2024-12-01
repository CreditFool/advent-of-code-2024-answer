import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class Day1 {
    public static void main(String[] args) {
        List<List<Integer>> input = readInput("./Day 1/input.txt");
        if (input.isEmpty()) {
            return;
        }

        System.out.println("distance: " + calculateDistance(input.get(0), input.get(1)));
        System.out.println("similiarity: " + calculateSimiliarity(input.get(0), input.get(1)));
    }

    private static List<List<Integer>> readInput(String path) {
        try {
            File file = new File(path);
            Scanner reader = new Scanner(file);

            List<Integer> listA = new ArrayList<>();
            List<Integer> listB = new ArrayList<>();
            String[] data = null;
            while (reader.hasNextLine()) {
                data = reader.nextLine().split(" ");
                listA.add(Integer.valueOf(data[0]));
                listB.add(Integer.valueOf(data[data.length - 1]));
            }
            reader.close();

            return List.of(listA, listB);

        } catch (Exception e) {
            System.err.println("Error when read input file: ");
            e.printStackTrace();

            return List.of();
        }
    }

    private static Integer calculateDistance(List<Integer> listA, List<Integer> listB) {
        listA.sort(Comparable::compareTo);
        listB.sort(Comparable::compareTo);

        Integer result = 0;
        for (int i = 0; i < listA.size(); i++) {
            result += Math.abs(listA.get(i) - listB.get(i));
        }

        return result;
    }

    private static Integer calculateSimiliarity(List<Integer> listA, List<Integer> listB) {
        HashMap<Integer, Integer> appearanceMap = new HashMap<>();
        for (Integer data : listA) {
            appearanceMap.put(data, 0);
        }

        for (Integer data : listB) {
            if (!appearanceMap.containsKey(data)) {
                continue;
            }
            appearanceMap.put(data, appearanceMap.get(data) + 1);
        }

        Integer result = 0;
        for (Map.Entry<Integer, Integer> entry : appearanceMap.entrySet()) {
            result += entry.getKey() * entry.getValue();
        }

        return result;
    }
}
