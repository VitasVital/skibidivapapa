#include "pch.h"
#include <iostream>
using namespace std;
struct Node
{
	int data;
	Node* next;
	Node* getNext()
	{
		return next;
	}
	void setNext(Node* node)
	{
		node->next = next;
	}

};

class LinkedList
{
private:
	Node* start = NULL;
	int length = 0;

public:


	Node* getStart()
	{
		return start;
	}
	void addLinkedLIst(int data)
	{
		Node*temp = new Node();
		temp->next = start;
		temp->data = data;
		start = temp;
	}

	void printThemALL()
	{
		for (Node* start = getStart(); start != NULL; start = start->getNext())
		{
			cout << start->data;
		}
	}


};



int main()
{
	LinkedList l;
	l.addLinkedLIst(1);
	l.addLinkedLIst(3);
	l.printThemALL();

}
/*
1. создаем объект класса, записываем в файл, считываем из файла
*/