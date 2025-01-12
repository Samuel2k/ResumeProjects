class Graph:
    def __init__(self):
        # Initialize an empty dictionary to store the railway network
        self.graph = {}

    def __str__(self):
        # Return a string representation of the graph (stations and their connections)
        if not self.graph:
            return "The railway network is empty."
        result = []
        for station, connections in self.graph.items():
            if connections:
                result.append(f"{station} - Connections:\n" + "\n".join([f"- {station} to {conn}" for conn in connections]))
            else:
                result.append(f"{station} - Connections: None")
        return "\n".join(result)

    def add_node(self, node):
        # Add a station to the railway network if it does not already exist
        if node in self.graph:
            print(f"Station in {node} already exists.")
        else:
            self.graph[node] = []
            print("Railway station created.")

    def delete_node(self, node):
        # Remove a station and all its connecting lines
        if node not in self.graph:
            print("Invalid station location.")
        else:
            # Remove the node from other stations' adjacency lists
            for connections in self.graph.values():
                if node in connections:
                    connections.remove(node)
            del self.graph[node]
            print(f"Station in {node} has been deleted.")

    def add_edge(self, node1, node2):
        # Prevent adding a railway line from a station to itself
        if node1 == node2:
            print("Cannot create a railway line from a station to itself.")
            return
        # Connect two stations with a direct one-way railway line
        if node1 in self.graph and node2 in self.graph:
            # Check if the connection already exists
            if node2 in self.graph[node1]:
                print(f"Direct railway line from {node1} to {node2} already exists.")
            else:
                self.graph[node1].append(node2)
                print(f"Direct railway line from {node1} to {node2} created.")
        else:
            print("One or both stations do not exist.")

    def is_connected(self):
        # Check if all stations are mutually reachable (strong connectivity in directed graph)
        if not self.graph:
            return False

        # Step 1: Check if all nodes are reachable from a starting node
        start_node = list(self.graph.keys())[0]
        visited = set()

        def dfs(node, graph, visited_set):
            visited_set.add(node)
            for neighbor in graph[node]:
                if neighbor not in visited_set:
                    dfs(neighbor, graph, visited_set)

        # Perform DFS from start_node in the original graph
        dfs(start_node, self.graph, visited)
        if len(visited) != len(self.graph):
            return False

        # Step 2: Check if all nodes can reach the start_node by reversing the graph
        reversed_graph = {node: [] for node in self.graph}
        for node in self.graph:
            for neighbor in self.graph[node]:
                reversed_graph[neighbor].append(node)

        visited.clear()
        dfs(start_node, reversed_graph, visited)

        if len(visited) == len(self.graph):
            return True
        else:
            return False

    def find_path(self, start, end, path=None):
        # Find and return a route between two stations if one exists using DFS
        if path is None:
            path = []

        path.append(start)

        if start == end:
            return path

        if start not in self.graph:
            return None

        for neighbor in self.graph[start]:
            if neighbor not in path:
                result = self.find_path(neighbor, end, path.copy())
                if result:
                    return result

        return None

# Main program loop with menu-driven interface
def main():
    g = Graph()

    while True:
        print("\nRAILWAY MANAGEMENT")
        print("Enter a number corresponding to the option:")
        print("1. SHOW railway network")
        print("2. ADD a new station to the railway network")
        print("3. DELETE a station from the railway network")
        print("4. CONNECT a start & end station with a direct railway line")
        print("5. CHECK if the entire network is connected")
        print("6. FIND out if a railway line exists between two stations")
        print("Q. QUIT program")

        user_input = input("\nEnter your input: ").upper()

        if user_input == "1":
            print("\nSTATIONS:")
            print(g)
        elif user_input == "2":
            station_name = input("Enter the location of the new railway station: ")
            g.add_node(station_name)
        elif user_input == "3":
            station_name = input("Enter the name of the station to delete from the railway network: ")
            g.delete_node(station_name)
        elif user_input == "4":
            start_station = input("Enter the start station's location: ")
            end_station = input("Enter the end station's location: ")
            g.add_edge(start_station, end_station)
        elif user_input == "5":
            if g.is_connected():
                print("All stations connected to network.")
            else:
                print("Railway network not yet fully implemented.")
        elif user_input == "6":
            start_station = input("Enter the start station's location: ")
            end_station = input("Enter the end station's location: ")
            path = g.find_path(start_station, end_station)
            if path:
                print(f"Railway line exists: {' to '.join(path)}")
            else:
                print(f"No such line exists from {start_station} to {end_station}.")
        elif user_input == "Q":
            print("Exiting program.")
            break
        else:
            print("Invalid input. Please try again.")

if __name__ == "__main__":
    main()
