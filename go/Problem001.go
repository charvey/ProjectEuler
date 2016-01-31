package main

import "fmt"

func main() {
	count := 0
	for l := 12; l < 1500000; l++ {
		if hasUniqueTriangle(l) {
			count++
		}
	}

	fmt.Println(count)
}

func hasUniqueTriangle(l int) bool {

}
